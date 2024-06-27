# ./src/apps/gestao_de_projeto/models/status_de_historia_de_usuario.py

from django.db import models
from django.db.models import UniqueConstraint, Index

class StatusDeHistoriaDeUsuario(models.Model):
	descricao = models.CharField(max_length=150)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'status de historia de usuário'
		verbose_name_plural = 'statuss de historias de usuários'
		db_table = 'status_de_historia_de_usuario'
		constraints = [
			UniqueConstraint(fields=['descricao'], name='unique_desc_stat_de_hist_de_usu'),
		]
		indexes = [
			Index(fields=['descricao'], name='idx_desc_stat_de_hist_de_usu'),
		]