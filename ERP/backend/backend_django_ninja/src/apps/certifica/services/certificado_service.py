# ./src/apps/certifica/services/certificado_service.py

from ..data.certificado_data import CertificadoData

class CertificadoService:
	@staticmethod
	def inserir(dados):
		return CertificadoData.inserir(dados)

	@staticmethod
	def buscar_todos():
		return CertificadoData.buscar_todos()

	@staticmethod
	def buscar_por_id(id):
		return CertificadoData.buscar_por_id(id)

	@staticmethod
	def alterar(id, dados):
		certificado = CertificadoData.buscar_por_id(id)
		return CertificadoData.alterar(certificado, dados)

	@staticmethod
	def excluir(id):
		certificado = CertificadoData.buscar_por_id(id)
		CertificadoData.excluir(certificado)
