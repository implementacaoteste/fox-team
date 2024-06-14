from reportlab.lib.pagesizes import letter
from reportlab.pdfgen import canvas

def criar_pdf(nome_arquivo):
    c = canvas.Canvas(nome_arquivo, pagesize=letter)
    c.drawString(100, 750, "Olá mundo")
    c.save()

if __name__ == "__main__":
    nome_arquivo = "documento.pdf"
    criar_pdf(nome_arquivo)
    print(f"PDF criado com sucesso: {nome_arquivo}")
