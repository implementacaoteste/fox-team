# ./src/apps/certifica/models/certificado.py

from django.db import models

class Certificado(models.Model):
	descricao = models.CharField(max_length=150)
	ativo = models.BooleanField(default=True)

	def __str__(self):
		return self.descricao
