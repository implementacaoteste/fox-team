# ./src/apps/gestao_de_projeto/services/tarefa_service.py

import logging
from django.db.utils import IntegrityError
from ..data.tarefa_data import TarefaData

class TarefaService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir tarefa com os seguintes dados: {dados}")
		try:
			return TarefaData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir tarefa: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir tarefa: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os tarefas")
		try:
			return TarefaData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todas as tarefas: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todas as tarefas: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar tarefa por id")
		try:
			return TarefaData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar tarefa por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar tarefa por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar tarefa de id: {id}, com os dados: {dados}")
		try:
			tarefa = TarefaData.buscar_por_id(id)
			return TarefaData.alterar(tarefa, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar tarefa: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar tarefa: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir tarefa de id: {id}")
		try:
			tarefa = TarefaData.buscar_por_id(id)
			TarefaData.excluir(tarefa)
			logging.info(f"tarefa excluída: {tarefa}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir tarefa: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir tarefa: {str(e)}")
