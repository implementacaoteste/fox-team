# ./src/apps/gestao_de_projeto/models/tarefa.py

from django.db import models
from django.db.models import UniqueConstraint, Index
from django.utils import timezone
from django.core.exceptions import ValidationError
from django.db.models import JSONField
from .historia_de_usuario import HistoriaDeUsuario
from .projeto import Projeto
from .sprint import Sprint
from .status_de_tarefa import StatusDeTarefa
from apps.configuracao.models.usuario import Usuario

class Tarefa(models.Model):
	titulo = models.CharField(max_length=150)    
	descricao_detalhada = models.TextField(null=True, blank=True)
	anexo = JSONField(blank=True, default=list)
	status = models.ForeignKey(StatusDeTarefa, on_delete=models.PROTECT, related_name='tarefas')
	participantes = models.ManyToManyField(Usuario, related_name='tarefas_participantes')
	testadores = models.ManyToManyField(Usuario, related_name='tarefas_testadores')
	peso = models.IntegerField(choices=[(i, str(i)) for i in range(5)], default=0)
	projeto = models.ForeignKey(Projeto, on_delete=models.PROTECT, related_name='tarefas')
	prioridade = models.IntegerField(choices=[(i, str(i)) for i in range(5)], default=0)
	historia_de_usuario = models.ForeignKey(HistoriaDeUsuario, on_delete=models.CASCADE, related_name='tarefas')
	sprint = models.ForeignKey(Sprint, on_delete=models.PROTECT, related_name='tarefas')
	data_prevista = models.DateField(null=True, blank=True)
	data_entrega = models.DateField(null=True, blank=True)
	data_cadastro = models.DateTimeField(default=timezone.now)

	def __str__(self):
		return self.descricao

	class Meta:
		verbose_name = 'tarefa'
		verbose_name_plural = 'tarefas'
		db_table = 'tarefa'
		constraints = [
			UniqueConstraint(fields=['titulo'], name='unique_titulo_tarefa'),
		]
		indexes = [
			Index(fields=['titulo'], name='idx_titulo_tarefa'),
		]