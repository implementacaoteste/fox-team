import fitz  # PyMuPDF

input_pdf_path = 'documento_assinado.pdf'

doc = fitz.open(input_pdf_path)

metadata = doc.metadata
if metadata:
    print(metadata)
else:
    print("Nenhum metadado encontrado.")

doc.close()
