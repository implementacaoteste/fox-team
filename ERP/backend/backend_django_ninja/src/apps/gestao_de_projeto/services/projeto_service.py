# ./src/apps/gestao_de_projeto/services/projeto_service.py

import logging
from django.db.utils import IntegrityError
from ..data.projeto_data import ProjetoData

class ProjetoService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir projeto com os seguintes dados: {dados}")
		try:
			return ProjetoData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir projeto: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir projeto: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os projetos")
		try:
			return ProjetoData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todos os projetos: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todos os projetos: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar projeto por id")
		try:
			return ProjetoData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar projeto por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar projeto por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar projeto de id: {id}, com os dados: {dados}")
		try:
			projeto = ProjetoData.buscar_por_id(id)
			return ProjetoData.alterar(projeto, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar projeto: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar projeto: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir projeto de id: {id}")
		try:
			projeto = ProjetoData.buscar_por_id(id)
			ProjetoData.excluir(projeto)
			logging.info(f"projeto excluído: {projeto}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir projeto: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir projeto: {str(e)}")
