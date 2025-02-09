#!/bin/bash
#https://gitnet.fr/deblan/shell-base/raw/branch/main/script

main() {
  while getopts "l:hvi:o:" option; do
  case "${option}" in
        h) help; exit 0;;
        l) LOG_VERBOSE="$OPTARG";;
        v) LOG_VERBOSE="debug";;
        i) INPUT_DIR="$OPTARG";;
        o) OUTPUT_DIR="$OPTARG";;
        ?) log error "$(usage)"; exit 1;;
  esac
  done

  # Check mandatory params
  if [ -z "${INPUT_DIR}" ]; then
    log error "Input directory is mandatory."
    help
    exit 3000
  fi

  if [ -z "${OUTPUT_DIR}" ]; then
    log error "Output directory is mandatory."
    help
    exit 3001
  fi

  # Check if the ./png directory exists
  if [ ! -d "${INPUT_DIR}" ]; then
    echo "Directory "${INPUT_DIR}" does not exist."
    exit 1

  fi
  if [ ! -d "${OUTPUT_DIR}" ]; then
    log info "Create output directory '${OUTPUT_DIR}'"
    mkdir -p "${OUTPUT_DIR}"
  fi

  # Monitor unbound variables
  set -eu
  for COURSE_NAME in $(find "${INPUT_DIR}" -mindepth 1 -maxdepth 1 -type d -exec basename {} \;)
  do
      ./pdf.sh -i "${INPUT_DIR}/${COURSE_NAME}" -o "${OUTPUT_DIR}/${COURSE_NAME}".pdf
  done
  exit 0
}

##############
# Help
##############
usage() {
  printf "Usage: %s [-l DEBUG_LEVEL] [-h] -i [input_directory] -o [output_directory]\n" "$0"
}

help() {
  cat << EOH
  SYNOPSIS
  $0 [-l DEBUG_LEVEL] [-h] -i [input_directory] -o [output_directory]

  DESCRIPTION
      $0 for all subdirs of [input_directory] convert all png into pdf.
      pdf are named according to original subdirectory name.

  OPTIONS
      -i <dir>
            (Mandatory) Input directory
      -o <filename>
            (Mandatory) Output directory
      -h    Show this help
      -v    Verbose
      -l debug|info|notice|warning|error
            Debug level
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

