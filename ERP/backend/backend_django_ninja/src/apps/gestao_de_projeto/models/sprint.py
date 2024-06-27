# ./src/apps/gestao_de_projeto/models/sprint.py

from django.db import models
from django.db.models import UniqueConstraint, Index
from .projeto import Projeto
from django.utils import timezone

class Sprint(models.Model):
	titulo = models.CharField(max_length=150)
	entregue = models.BooleanField(default=False)
	projeto = models.ForeignKey(Projeto, on_delete=models.PROTECT, related_name='sprints')
	ativo = models.BooleanField(default=True)
	data_prevista = models.DateField(null=True, blank=True)
	data_entrega = models.DateField(null=True, blank=True)
	data_cadastro = models.DateTimeField(default=timezone.now)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'sprint'
		verbose_name_plural = 'sprints'
		db_table = 'sprint'
		constraints = [
			UniqueConstraint(fields=['titulo'], name='unique_titulo_sprint'),
		]
		indexes = [
			Index(fields=['titulo'], name='idx_titulo_sprint'),
		]