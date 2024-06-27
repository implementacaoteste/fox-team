# ./src/apps/configuracao/models/usuario.py

from django.db import models
from django.db.models import UniqueConstraint, Index
from .grupo_de_usuario import GrupoDeUsuario

class Usuario(models.Model):
	nome = models.CharField(max_length=150)
	nome_usuario = models.CharField(max_length=150, unique=True)
	email = models.EmailField(max_length=150, unique=True)
	grupos = models.ManyToManyField(GrupoDeUsuario, related_name='usuario_usuarios_de_grupos')
	url_foto = models.CharField(max_length=150, blank=True, null=True)
	ativo = models.BooleanField(default=True)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'usuário'
		verbose_name_plural = 'usuários'
		db_table = 'usuario'
		constraints = [
			UniqueConstraint(fields=['nome_usuario'], name='unique_nome_usuario'),
		]
		indexes = [
			Index(fields=['nome_usuario'], name='idx_nome_usuario'),
		]