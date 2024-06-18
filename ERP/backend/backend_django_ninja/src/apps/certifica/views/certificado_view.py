import os
import subprocess
from ninja import Router
from ninja.files import UploadedFile
from django.http import FileResponse, JsonResponse
from ..logger import get_logger  # Importe seu logger aqui, se necessário
import uuid
import PyPDF2

certificado_router = Router()

@certificado_router.post("/assinar/")
def assinar_pdf_view(request, pdf: UploadedFile):
    logger = get_logger()  # Obtenha o logger, se necessário
    logger.info("Início do método assinar PDF")
    
    # Define o caminho para a pasta de PDFs e de PDFs assinados
    caminho_pdfs = os.path.abspath(os.path.join(os.path.dirname(__file__), '../../../arquivos/pdfs'))
    caminho_pdfs_assinados = os.path.abspath(os.path.join(os.path.dirname(__file__), '../../../arquivos/pdfs/assinados'))
    
    if os.path.exists(caminho_pdfs):
        logger.info(f'Existe o diretório de PDFs: {caminho_pdfs}')
    else:
        logger.info(f'Não existe o diretório de PDFs: {caminho_pdfs}')
        return JsonResponse({'erro': 'Diretório de PDFs não existe'}, status=500)

    if os.path.exists(caminho_pdfs_assinados):
        logger.info(f'Existe o diretório de PDFs assinados: {caminho_pdfs_assinados}')
    else:
        logger.info(f'Não existe o diretório de PDFs assinados: {caminho_pdfs_assinados}')
        return JsonResponse({'erro': 'Diretório de PDFs assinados não existe'}, status=500)

    # Garante que a pasta exista ou a cria se não existir
    os.makedirs(caminho_pdfs, exist_ok=True)
    os.makedirs(caminho_pdfs_assinados, exist_ok=True)
    
    # Gera um GUID único para o nome do arquivo
    guid = str(uuid.uuid4())

    # Define os caminhos para os arquivos
    caminho_pdf_original = os.path.join(caminho_pdfs, f'{guid}.pdf')
    caminho_pdf_assinado = os.path.join(caminho_pdfs_assinados, f'{guid}.pdf.assinado')

    try:
        # Salva o arquivo PDF original na pasta de PDFs com o nome GUID
        with open(caminho_pdf_original, 'wb') as f:
            f.write(pdf.read())

        # Verifica se o arquivo foi salvo
        if os.path.exists(caminho_pdf_original):
            logger.info(f'PDF original salvo com sucesso: {caminho_pdf_original}')
        else:
            logger.error(f'Falha ao salvar o PDF original: {caminho_pdf_original}')
            return JsonResponse({'erro': 'Falha ao salvar o PDF original'}, status=500)

        # Abre o PDF original para leitura e prepara para copiar para o PDF assinado
        with open(caminho_pdf_original, 'rb') as pdf_original:
            pdf_reader = PyPDF2.PdfReader(pdf_original)
            pdf_writer = PyPDF2.PdfWriter()

            # Copia todas as páginas do PDF original para o PDF de saída
            for page_num in range(len(pdf_reader.pages)):
                pdf_writer.add_page(pdf_reader.pages[page_num])

            # Cria o arquivo de saída temporário para o PDF assinado
            caminho_pdf_assinado_temp = os.path.join(caminho_pdfs_assinados, f'{guid}_temp.pdf')
            with open(caminho_pdf_assinado_temp, 'wb') as f:
                pdf_writer.write(f)

        # Caminhos para os certificado e chave privada
        caminho_certificado = os.path.abspath(os.path.join(os.path.dirname(__file__), '../../../config/certificado.pem'))
        caminho_chave_privada = os.path.abspath(os.path.join(os.path.dirname(__file__), '../../../config/private_key.pem'))

        # Monta o comando OpenSSL para assinar o PDF temporário
        comando = [
            'openssl', 'smime', '-sign',
            '-in', caminho_pdf_assinado_temp,
            '-out', caminho_pdf_assinado,
            '-signer', caminho_certificado,
            '-inkey', caminho_chave_privada,
            '-outform', 'DER', '-binary', '-passin', 'pass:teste'
        ]

        # Executa o comando OpenSSL para assinar o PDF temporário
        subprocess.run(comando, check=True)
        logger.info(f'PDF assinado com sucesso: {caminho_pdf_assinado}')

        # Remove o arquivo temporário
        os.remove(caminho_pdf_assinado_temp)

        # Retorna o PDF assinado como um arquivo de download
        with open(caminho_pdf_assinado, 'rb') as f:
            response = FileResponse(f)
            response['Content-Type'] = 'application/pdf'
            response['Content-Disposition'] = f'attachment; filename="{guid}.pdf.assinado"'
            return response

    except Exception as e:
        logger.error(f"Erro ao processar assinatura de PDF: {str(e)}")
        return JsonResponse({'erro': str(e)}, status=500)
