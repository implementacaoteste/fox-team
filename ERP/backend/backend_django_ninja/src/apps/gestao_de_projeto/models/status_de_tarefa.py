# ./src/apps/gestao_de_projeto/models/status_de_tarefa.py

from django.db import models
from django.db.models import UniqueConstraint, Index

class StatusDeTarefa(models.Model):
	descricao = models.CharField(max_length=150)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'status de tarefa'
		verbose_name_plural = 'statuss de tarefas'
		db_table = 'status_de_tarefa'
		constraints = [
			UniqueConstraint(fields=['descricao'], name='unique_desc_stat_de_tarefa'),
		]
		indexes = [
			Index(fields=['descricao'], name='idx_desc_stat_de_tarefa'),
		]