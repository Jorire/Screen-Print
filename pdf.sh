#!/bin/bash
# https://gitnet.fr/deblan/shell-base/raw/branch/main/script

main() {
  while getopts "l:hvi:o:" option; do
  case "${option}" in
        h) help; exit 0;;
        l) LOG_VERBOSE="$OPTARG";;
        v) LOG_VERBOSE="debug";;
        i) INPUT_DIR="$OPTARG";;
        o) OUTPUT_FILE="$OPTARG";;
        ?) log error "$(usage)"; exit 1;;
  esac
  done

  # Check mandatory params
  if [ -z "${INPUT_DIR}" ]; then
    log error "Input directory is mandatory."
    help
    exit 3000
  fi

  if [ -z "${OUTPUT_FILE}" ]; then
    log error "Output file is mandatory."
    help
    exit 3001
  fi

  # Monitor unbound variables
  set -eu

  # Check dependencies
  if ! command -v img2pdf 2>&1 >/dev/null
  then
      log error "img2pdf is not installed (sudo apt install img2pdf)."
      help
      exit 4000
  fi

  if ! command -v ocrmypdf 2>&1 >/dev/null
  then
      log error "ocrmypdf is not installed (sudo apt install ocrmypdf)."
      help
      exit 4001
  fi

  if ! command -v jbig2 2>&1 >/dev/null
  then
      log error "jbig2 is not installed (sudo apt install jbig2)."
      help
      exit 4001
  fi
  

  # Get OUTPUT_FILE directory
  OUTPUT_FILE_DIR=$(dirname -- "$OUTPUT_FILE")
  # Get OUTPUT_FILE filename without directory
  OUTPUT_FILE_NAME=$(basename -- "$OUTPUT_FILE")
  # Extract extension from OUTPUT_FILE_NAME
  OUTPUT_FILE_EXT="${OUTPUT_FILE_NAME##*.}"
  # Update OUTPUT_FILE_NAME to remove extension
  OUTPUT_FILE_NAME="${OUTPUT_FILE_NAME%.*}"
  log debug "${OUTPUT_FILE} -> dir '${OUTPUT_FILE}' filename '$OUTPUT_FILE_NAME' extension '$OUTPUT_FILE_EXT'"

  # Convert
  ORIGINAL_OUTPUT_FILE="${OUTPUT_FILE_DIR}/${OUTPUT_FILE_NAME}_original.${OUTPUT_FILE_EXT}"
  log info "Convert '${INPUT_DIR}/*.png' to '${ORIGINAL_OUTPUT_FILE}'"
  img2pdf $(ls -1 ${INPUT_DIR}/*.png | sort -V) --output "${ORIGINAL_OUTPUT_FILE}" > /dev/null
  retVal=$?
  if [[ $retVal -ne 0 ]]; then
      log error "Error converting '${INPUT_DIR}/*.png' to '${ORIGINAL_OUTPUT_FILE}'"
      exit 1000
  fi

  # OCR
  log info "OCR '${ORIGINAL_OUTPUT_FILE}' into '${OUTPUT_FILE}'"
  ocrmypdf --optimize 3 ${ORIGINAL_OUTPUT_FILE} ${OUTPUT_FILE}  > /dev/null
  retVal=$?
  if [[ $retVal -ne 0 ]]; then
      log error "Error ocr on '${OUTPUT_FILE}'"
      exit 1000
  fi
  exit 0
}


##############
# Help
##############
usage() {
  printf "Usage: %s [-l DEBUG_LEVEL] [-h] -i [input_directory] -o [output_file]\n" "$0"
}

help() {
  cat << EOH
  SYNOPSIS
  $0 [-l DEBUG_LEVEL] [-h] -i [input_directory] -o [output_file]

  DESCRIPTION
      $0 convert png files into two PDF (with/without OCR)

  OPTIONS
      -i <dir>
            (Mandatory) Input directory
      -o <filename>
            (Mandatory) Output file
      -h    Show this help
      -v    Verbose
      -l debug|info|notice|warning|error
            Debug level

  DEPENDENCIES
      imagemagick: 'sudo apt install img2pdf'
      ocrmypdf:    'sudo apt install ocrmypdf'
      jbig2:    'sudo apt install jbig2'
EOH
}

##############
# Boilerplate
##############
on_interrupt() {
  log -l warning ""
  log -l warning "Process aborted!"

  exit 130
}


log() {
  LOG_VERBOSE="${LOG_VERBOSE:-info}"
  LEVEL=$1
  MESSAGE=$2
  TIME="$(printf "[%s] " "$(date +'%Y-%m-%dT%H:%M:%S.%s')")"

  if [ -t 2 ] && [ -z "${NO_COLOR-}" ]; then
    case "${LEVEL}" in
      debug) COLOR="$(tput setaf 5)";;
      info) COLOR="$(tput setaf 4)";;
      warning) COLOR="$(tput setaf 3)";;
      error) COLOR="$(tput setaf 1)";;
      *) COLOR="$(tput sgr0)";;
    esac
  fi

  case "${LEVEL}" in
    debug)
      LEVEL_LABEL="DEBUG";;
    info)
      LEVEL_LABEL="INFO ";;
    warning)
      LEVEL_LABEL="WARN ";;
    error)
      LEVEL_LABEL="ERROR";;
    *) LEVEL_LABEL="????";;
  esac

  case "${LEVEL}" in
    debug)
      LEVEL=100;;
    info)
      LEVEL=250;;
    warning)
      LEVEL=300;;
    error)
      LEVEL=400;;
    *) LEVEL=200;;
  esac

  case "${LOG_VERBOSE}" in
    debug) LOG_VERBOSE_VALUE=100;;
    info) LOG_VERBOSE_VALUE=250;;
    warning) LOG_VERBOSE_VALUE=300;;
    error) LOG_VERBOSE_VALUE=400;;
    *) LOG_VERBOSE_VALUE=200;;
  esac

  if [ $LEVEL -ge $LOG_VERBOSE_VALUE ]; then
    printf "%s%s%s %s %s\n" "${COLOR:-}" "${TIME:-}" "[$LEVEL_LABEL]" "$MESSAGE" "$(tput sgr0)">&2
  fi
}

trap on_interrupt INT

main "$@"
