# ./src/apps/configuracao/models/permissao.py

from django.db import models

from django.db.models import UniqueConstraint, Index

class Permissao(models.Model):
	descricao = models.CharField(max_length=150)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'permissão'
		verbose_name_plural = 'permissões'
		db_table = 'permissao'
		constraints = [
			UniqueConstraint(fields=['descricao'], name='unique_descricao_permissao'),
		]
		indexes = [
			Index(fields=['descricao'], name='idx_descricao_permissao'),
		]