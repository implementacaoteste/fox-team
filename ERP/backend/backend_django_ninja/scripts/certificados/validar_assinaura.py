import os
from PyPDF2 import PdfReader
from Crypto.Signature import pkcs1_15
from Crypto.Hash import SHA256
from Crypto.PublicKey import RSA

def load_public_key(file_path):
    with open(file_path, 'rb') as f:
        public_key = RSA.import_key(f.read())
    return public_key

def calculate_pdf_hash(file_path):
    with open(file_path, 'rb') as f:
        content = f.read()
    pdf_hash = SHA256.new(content)
    return pdf_hash

def validate_signature(input_pdf_path, public_key_path):
    public_key = load_public_key(public_key_path)

    reader = PdfReader(input_pdf_path)
    
    # Verificar se há metadados no PDF
    if '/Metadata' in reader.trailer.keys():
        metadata = reader.trailer['/Metadata'].getData()
        print(f"Metadados encontrados:\n{metadata.decode('utf-8')}")
    else:
        print("Nenhum metadado encontrado.")

    # Verificar se há assinatura no PDF
    if '/Signature' in reader.trailer.keys():
        signature_hex = reader.trailer['/Signature'].getData().hex()
        hash_hex = reader.trailer['/Hash'].getData().hex()

        # Recalcular o hash do PDF
        recalculated_hash = calculate_pdf_hash(input_pdf_path).hexdigest()

        # Imprimir os hashes para depuração
        print(f"Original Hash: {hash_hex}")
        print(f"Recalculated Hash: {recalculated_hash}")

        # Comparar os hashes
        if hash_hex != recalculated_hash:
            print("O conteúdo do PDF foi alterado.")
            return

        # Validar a assinatura
        signature = bytes.fromhex(signature_hex)
        try:
            pkcs1_15.new(public_key).verify(SHA256.new(bytes.fromhex(hash_hex)), signature)
            print("A assinatura é válida.")
        except (ValueError, TypeError):
            print("A assinatura não é válida.")
    else:
        print("Nenhuma assinatura encontrada.")

current_dir = os.path.dirname(os.path.abspath(__file__))
public_key_path = os.path.join(current_dir, 'public_key.pem')
signed_pdf_path = os.path.join(current_dir, 'documento_assinado.pdf')

try:
    validate_signature(signed_pdf_path, public_key_path)
except FileNotFoundError as e:
    print(f"Erro ao processar arquivos: {e}")
except Exception as e:
    print(f"Erro inesperado: {e}")
