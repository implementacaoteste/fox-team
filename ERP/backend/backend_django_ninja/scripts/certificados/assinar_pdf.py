import os
from PyPDF2 import PdfReader, PdfWriter
from PyPDF2.generic import DictionaryObject, NameObject, create_string_object
from Crypto.Signature import pkcs1_15
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA

# Função para carregar a chave privada
def load_private_key(file_path, password='teste'):
    with open(file_path, 'rb') as f:
        private_key = RSA.import_key(f.read(), passphrase=password)
    return private_key

# Função para calcular o hash do conteúdo do PDF
def calculate_pdf_hash(file_path):
    with open(file_path, 'rb') as f:
        content = f.read()
    pdf_hash = SHA256.new(content)
    return pdf_hash

# Função para assinar o hash
def sign_hash(hash, private_key):
    signature = pkcs1_15.new(private_key).sign(hash)
    return signature

# Função para adicionar assinatura e hash no PDF
def add_signature_to_pdf(input_pdf_path, output_pdf_path, hash, signature):
    reader = PdfReader(input_pdf_path)
    writer = PdfWriter()

    for page_num in range(len(reader.pages)):
        page = reader.pages[page_num]
        writer.add_page(page)

    # Adicionando o hash e a assinatura no PDF como metadata
    metadata = DictionaryObject()
    metadata.update({
        NameObject('/Hash'): create_string_object(hash.hexdigest()),
        NameObject('/Signature'): create_string_object(signature.hex())
    })
    writer.add_metadata(metadata)

    with open(output_pdf_path, 'wb') as output_pdf:
        writer.write(output_pdf)

# Caminhos para os arquivos
current_dir = os.path.dirname(os.path.abspath(__file__))
private_key_path = os.path.join(current_dir, 'private_key.pem')
input_pdf_path = os.path.join(current_dir, 'documento.pdf')
output_pdf_path = os.path.join(current_dir, 'documento_assinado.pdf')

try:
    # Carregar chave privada e assinar o conteúdo
    password = 'teste'  # input("Enter PEM pass phrase: ").encode('utf-8')
    private_key = load_private_key(private_key_path, password=password)

    # Calcular o hash do conteúdo
    pdf_hash = calculate_pdf_hash(input_pdf_path)

    # Gerar a assinatura
    signature = sign_hash(pdf_hash, private_key)

    # Adicionar a assinatura e o hash ao PDF
    add_signature_to_pdf(input_pdf_path, output_pdf_path, pdf_hash, signature)

    print("Documento PDF assinado com sucesso.")

except FileNotFoundError as e:
    print(f"Erro ao processar arquivos: {e}")
except Exception as e:
    print(f"Erro inesperado: {e}")
