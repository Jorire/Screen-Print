# Screen Print
Automated screen capture with PDF output.
A screen click is performed between each capture.
Screenshots are saved in jpg format, and a PDF containing all of them is produced.

## Altenate version for PDF processing
Resulting pdf may be invalid (missing page, badly decoded image, ...) and text search will not be possible.   
#### Dependencies:
img2pdf ocrmypdf, JBIG2 are required (`sudo apt install img2pdf ocrmypdf jbig2`).

### Process one batch of png
You may find a working shell script in this repository `pdf.sh` that will take all png (in alphabetic order) and create two PDF.

*ie:* `./pdf.sh -i ./courses/all/ -o my_pdf.pdf`  
Input:
- ./courses/
    - all/
        - 1.png
        - 2.png
        - 3.png
        - 4.png
        - 5.png
        - 6.png

Output:
- ./pdf/
    - my_pdf.pdf *(with ocr)*
    - my_pdf_original.pdf

### Process multiple inputs
Another shell script `pdf_all.sh` will batch process all subdirectories of input directory.  
*ie:* `./pdf_all.sh -i courses/ -o pdf`

Input:
- ./courses/
    - all/
        - 1.png
        - 2.png
        - 3.png
        - 4.png
        - 5.png
        - 6.png
    - chapter1/
        - 1.png
        - 2.png
    - chapter2/
        - 3.png
        - 4.png
        - 5.png
    - chapter3/
        - 6.png

Output:
- ./pdf/
    - all.pdf *(with ocr)*
    - all_original.pdf
    - chapter1.pdf *(with ocr)*
    - chapter1_original.pdf
    - chapter2.pdf *(with ocr)*
    - chapter2_original.pdf
    - chapter3.pdf *(with ocr)*
    - chapter3_original.pdf

