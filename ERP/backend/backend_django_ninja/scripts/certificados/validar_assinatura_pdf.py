import subprocess

def validar_assinatura_pdf(caminho_pdf_assinado, caminho_pdf_original, caminho_certificado):
    # Comando OpenSSL para verificar a assinatura do PDF
    comando = [
        'openssl', 'smime', '-verify',
        '-in', caminho_pdf_assinado,
        '-inform', 'DER',
        '-content', caminho_pdf_original,
        '-noverify',
        '-signer', caminho_certificado,
        '-out', 'verificacao.txt'
    ]

    # Executando o comando OpenSSL para verificar a assinatura
    try:
        subprocess.run(comando, check=True, capture_output=True)
        print("Verificação da assinatura bem-sucedida.")
    except subprocess.CalledProcessError as e:
        print(f"Erro ao verificar a assinatura: {e}")
        return

    # Lendo o resultado da verificação em modo binário
    with open('verificacao.txt', 'rb') as f:
        resultado = f.read()
        print(resultado.decode('utf-8', errors='ignore'))  # Decodifica como UTF-8

# Caminhos dos arquivos
caminho_pdf_assinado = '/home/erisvaldo/git/ImplementacaoTeste/fox-team/ERP/backend/backend_django_ninja/scripts/certificados/documento_assinado.pdf.assinado'
caminho_pdf_original = '/home/erisvaldo/git/ImplementacaoTeste/fox-team/ERP/backend/backend_django_ninja/scripts/certificados/documento_assinado.pdf'
caminho_certificado = '/home/erisvaldo/git/ImplementacaoTeste/fox-team/ERP/backend/backend_django_ninja/scripts/certificados/certificado.pem'

# Chamada para validar a assinatura do PDF
validar_assinatura_pdf(caminho_pdf_assinado, caminho_pdf_original, caminho_certificado)
