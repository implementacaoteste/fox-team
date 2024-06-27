# ./src/apps/gestao_de_projeto/services/comentario_service.py

import logging
from django.db.utils import IntegrityError
from ..data.comentario_data import ComentarioData

class ComentarioService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir comentario com os seguintes dados: {dados}")
		try:
			return ComentarioData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir comentario: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir comentario: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os comentarios")
		try:
			return ComentarioData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todos os comentarios: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todos os comentarios: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar comentario por id")
		try:
			return ComentarioData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar comentario por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar comentario por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar comentario de id: {id}, com os dados: {dados}")
		try:
			comentario = ComentarioData.buscar_por_id(id)
			return ComentarioData.alterar(comentario, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar comentario: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar comentario: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir comentario de id: {id}")
		try:
			comentario = ComentarioData.buscar_por_id(id)
			ComentarioData.excluir(comentario)
			logging.info(f"comentario excluído: {comentario}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir comentario: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir comentario: {str(e)}")
