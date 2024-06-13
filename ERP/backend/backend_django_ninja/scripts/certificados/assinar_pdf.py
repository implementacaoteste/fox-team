import os
import hashlib
import PyMuPDF

def assinar_pdf(input_pdf_path, output_pdf_path, signature_text):
    # Abrir o arquivo PDF
    pdf_document = PyMuPDF.open(input_pdf_path)
    num_pages = len(pdf_document)

    # Criar um novo objeto de assinatura
    signature = PyMuPDF.fitz.PdfSignature()

    # Configurar a aparência da assinatura (opcional)
    signature.set_font(PyMuPDF.fitz.FONT_HELVETICA, 12)
    signature.set_text(signature_text)
    signature.set_color(0, 0, 1)  # Cor da assinatura: azul

    # Configurar a posição da assinatura (neste exemplo, no canto inferior direito da página)
    signature.set_location(num_pages - 1, [pdf_document.page(num_pages - 1).rect.width - 150, 20, 200, 50])

    # Configurar o motivo da assinatura (opcional)
    signature.set_reason("Documento assinado digitalmente")

    # Configurar o método de criptografia e hash (SHA256)
    signature.set_digest_algorithm(PyMuPDF.fitz.DIGEST_SHA256)

    # Assinar todas as páginas do PDF
    for page_num in range(num_pages):
        pdf_page = pdf_document.load_page(page_num)
        pdf_page.add_signature(signature)

    # Salvar o PDF assinado
    pdf_document.save(output_pdf_path)
    pdf_document.close()

    print(f"Documento PDF assinado com sucesso em: {output_pdf_path}")

if __name__ == "__main__":
    # Caminhos para os arquivos
    current_dir = os.path.dirname(os.path.abspath(__file__))
    input_pdf_path = os.path.join(current_dir, 'documento.pdf')
    output_pdf_path = os.path.join(current_dir, 'documento_assinado_pymupdf.pdf')

    # Texto da assinatura
    signature_text = "Assinado por: Seu Nome"

    # Assinar o PDF
    assinar_pdf(input_pdf_path, output_pdf_path, signature_text)
