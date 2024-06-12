import os
from cryptography.hazmat.primitives import hashes
from cryptography.hazmat.primitives.asymmetric import padding
from cryptography.hazmat.primitives.serialization import load_pem_public_key, load_pem_private_key

def carregar_chave_privada(file_path, senha=None):
    with open(file_path, 'rb') as f:
        private_key = load_pem_private_key(f.read(), password=senha)
    return private_key

def carregar_chave_publica(file_path):
    with open(file_path, 'rb') as f:
        public_key = load_pem_public_key(f.read())
    return public_key

def assinar_documento(conteudo_do_documento, chave_privada):
    if isinstance(conteudo_do_documento, str):
        conteudo_do_documento = conteudo_do_documento.encode('utf-8')

    assinatura = chave_privada.sign(
        conteudo_do_documento,
        padding.PKCS1v15(),
        hashes.SHA256()
    )
    return assinatura

# Função para verificar a assinatura
def verify_signature(conteudo_do_documento, assinatura, chave_publica):
    if isinstance(conteudo_do_documento, str):
        conteudo_do_documento = conteudo_do_documento.encode('utf-8')

    try:
        chave_publica.verify(
            assinatura,
            conteudo_do_documento,
            padding.PKCS1v15(),
            hashes.SHA256()
        )
        return True
    except Exception as e:
        print(f"Verificação falhou: {e}")
        return False

# Caminho para as chaves
diretorio_atual = os.path.dirname(os.path.abspath(__file__))
caminho_da_chave_privada = os.path.join(diretorio_atual, 'private_key.pem')
caminho_da_chave_publica = os.path.join(diretorio_atual, 'public_key.pem')

# Document content
documento_atual = "xml ou json do documento"

try:
    # Solicita a senha para a chave privada, se necessário
    senha = 'teste'.encode('utf-8') # input("informe a senha da chave privada: ").encode('utf-8')

    chave_privada = carregar_chave_privada(caminho_da_chave_privada, senha=senha)
    assinatura_do_documento = assinar_documento(documento_atual, chave_privada)
    
    # Carregar chave pública e verificar a assinatura
    chave_publica = carregar_chave_publica(caminho_da_chave_publica)
    e_valido = verify_signature(documento_atual, assinatura_do_documento, chave_publica)
    
    if e_valido:
        print("A assinatura é válida.")
    else:
        print("A assinatura não é válida.")
except FileNotFoundError as e:
    print(f"Erro ao processar chaves ou documento: {e}")
except Exception as e:
    print(f"Erro inesperado: {e}")
