# ./src/apps/gestao_de_projeto/models/projeto.py

from django.db import models
from django.db.models import UniqueConstraint, Index
from apps.configuracao.models.usuario import Usuario

class Projeto(models.Model):
	nome = models.CharField(max_length=150)
	descricao = models.TextField()
	participantes = models.ManyToManyField(Usuario, related_name='projetos_participantes')
	ativo = models.BooleanField(default=True)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'projeto'
		verbose_name_plural = 'projetos'
		db_table = 'projeto'
		constraints = [
			UniqueConstraint(fields=['nome'], name='unique_nome_projeto'),
		]
		indexes = [
			Index(fields=['nome'], name='idx_nome_projeto'),
		]