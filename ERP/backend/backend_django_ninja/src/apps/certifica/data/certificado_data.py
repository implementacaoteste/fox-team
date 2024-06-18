# ./src/apps/certifica/data/certificado_data.py

from ..models.certificado import Certificado

class CertificadoData:
	@staticmethod
	def inserir(dados):
		return Certificado.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return Certificado.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return Certificado.objects.get(id=id)

	@staticmethod
	def alterar(certificado, dados):
		for attr, valor in dados.items():
			setattr(certificado, attr, valor)
		certificado.save()
		return certificado

	@staticmethod
	def excluir(certificado):
		certificado.delete()
