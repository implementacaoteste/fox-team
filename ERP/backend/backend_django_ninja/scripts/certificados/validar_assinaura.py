import os
from PyPDF2 import PdfReader
from Crypto.Signature import pkcs1_15
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA

# Função para carregar a chave pública
def load_public_key(file_path):
    with open(file_path, 'rb') as f:
        public_key = RSA.import_key(f.read())
    return public_key

# Função para calcular o hash do conteúdo do PDF
def calculate_pdf_hash(file_path):
    with open(file_path, 'rb') as f:
        content = f.read()
    pdf_hash = SHA256.new(content)
    return pdf_hash

# Função para validar a assinatura do PDF
def validate_signature(input_pdf_path, public_key_path):
    reader = PdfReader(input_pdf_path)
    public_key = load_public_key(public_key_path)

    # Ler a assinatura e o hash do metadata
    metadata = reader.metadata
    signature_hex = metadata.get('/Signature')
    hash_hex = metadata.get('/Hash')
    if not signature_hex or not hash_hex:
        raise ValueError("Nenhuma assinatura ou hash encontrados no PDF.")

    signature = bytes.fromhex(signature_hex)
    original_hash = SHA256.new(bytes.fromhex(hash_hex)).digest()

    # Recalcular o hash do conteúdo do PDF
    recalculated_hash = calculate_pdf_hash(input_pdf_path).digest()

    # Comparar os hashes
    if original_hash != recalculated_hash:
        print("O conteúdo do PDF foi alterado.")
        return

    # Validar a assinatura
    try:
        pkcs1_15.new(public_key).verify(SHA256.new(original_hash), signature)
        print("A assinatura é válida.")
    except (ValueError, TypeError):
        print("A assinatura não é válida.")

# Caminhos para os arquivos
current_dir = os.path.dirname(os.path.abspath(__file__))
public_key_path = os.path.join(current_dir, 'public_key.pem')
signed_pdf_path = os.path.join(current_dir, 'documento_assinado.pdf')

try:
    # Validar a assinatura do PDF
    validate_signature(signed_pdf_path, public_key_path)

except FileNotFoundError as e:
    print(f"Erro ao processar arquivos: {e}")
except Exception as e:
    print(f"Erro inesperado: {e}")
