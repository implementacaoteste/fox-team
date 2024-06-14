import PyPDF2
import subprocess

def assinar_pdf(caminho_pdf, caminho_certificado, caminho_chave_privada, caminho_saida_assinado):
    # Abre o PDF original
    with open(caminho_pdf, 'rb') as pdf_original:
        pdf_reader = PyPDF2.PdfReader(pdf_original)
        pdf_writer = PyPDF2.PdfWriter()

        # Copia todas as páginas do PDF original para o PDF de saída
        for page_num in range(len(pdf_reader.pages)):
            pdf_writer.add_page(pdf_reader.pages[page_num])

        # Cria o arquivo de saída para o PDF assinado
        with open(caminho_saida_assinado, 'wb') as pdf_assinado:
            pdf_writer.write(pdf_assinado)

    # Comando OpenSSL para assinar o PDF
    comando = [
        'openssl', 'smime', '-sign',
        '-in', caminho_saida_assinado,
        '-out', caminho_saida_assinado + '.assinado',
        '-signer', caminho_certificado,
        '-inkey', caminho_chave_privada,
        '-outform', 'DER', '-binary', '-passin', 'pass:teste'
    ]

    # Executa o comando OpenSSL para assinar o PDF
    try:
        subprocess.run(comando, check=True)
        print(f'PDF assinado com sucesso: {caminho_saida_assinado}.assinado')
    except subprocess.CalledProcessError as e:
        print(f'Erro ao assinar o PDF: {e}')

# Caminhos dos arquivos
caminho_pdf = '/home/erisvaldo/git/ImplementacaoTeste/fox-team/ERP/backend/backend_django_ninja/scripts/certificados/documento.pdf'
caminho_certificado = '/home/erisvaldo/git/ImplementacaoTeste/fox-team/ERP/backend/backend_django_ninja/scripts/certificados/certificado.pem'
caminho_chave_privada = '/home/erisvaldo/git/ImplementacaoTeste/fox-team/ERP/backend/backend_django_ninja/scripts/certificados/private_key.pem'
caminho_saida_assinado = '/home/erisvaldo/git/ImplementacaoTeste/fox-team/ERP/backend/backend_django_ninja/scripts/certificados/documento_assinado.pdf'

# Chamada para assinar o PDF
assinar_pdf(caminho_pdf, caminho_certificado, caminho_chave_privada, caminho_saida_assinado)
