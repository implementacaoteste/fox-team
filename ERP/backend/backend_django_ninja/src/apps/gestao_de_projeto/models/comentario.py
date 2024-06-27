# ./src/apps/gestao_de_projeto/models/comentario.py

from .tarefa import Tarefa
from django.db import models
from .historia_de_usuario import HistoriaDeUsuario
from django.db.models import UniqueConstraint, Index
from apps.configuracao.models.usuario import Usuario

class Comentario(models.Model):
	descricao = models.CharField(max_length=150)
	usuario = models.ForeignKey(Usuario, on_delete=models.PROTECT, related_name='comentarios')
	tarefa = models.ForeignKey(Tarefa, on_delete=models.PROTECT, related_name='comentarios')
	historia_de_usuario = models.ForeignKey(HistoriaDeUsuario, on_delete=models.PROTECT, related_name='comentarios')
	automatico = models.BooleanField(default=False)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'comentario'
		verbose_name_plural = 'comentarios'
		db_table = 'comentario'
		constraints = [
			UniqueConstraint(fields=['descricao'], name='unique_descricao_comentario'),
		]
		indexes = [
			Index(fields=['descricao'], name='idx_descricao_comentario'),
		]

		