# ./src/apps/configuracao/models/grupo_de_usuario.py

from django.db import models

from django.db.models import UniqueConstraint, Index

class GrupoDeUsuario(models.Model):
	descricao = models.CharField(max_length=150)
	ativo = models.BooleanField(default=True)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'grupo de usuário'
		verbose_name_plural = 'grupos de usuários'
		db_table = 'grupo_de_usuario'
		constraints = [
			UniqueConstraint(fields=['descricao'], name='unique_des_grupo_de_usuario'),
		]
		indexes = [
			Index(fields=['descricao'], name='idx_desc_grupo_de_usuario'),
		]