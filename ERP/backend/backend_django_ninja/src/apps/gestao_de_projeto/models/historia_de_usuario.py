# ./src/apps/gestao_de_projeto/models/historia_de_usuario.py

from django.db import models
from django.db.models import UniqueConstraint, Index
from django.db.models import JSONField
from django.utils import timezone
from .status_de_historia_de_usuario import StatusDeHistoriaDeUsuario
from .projeto import Projeto
from apps.configuracao.models.usuario import Usuario

class HistoriaDeUsuario(models.Model):
	titulo = models.CharField(max_length=150)
	descricao_detalhada = models.TextField(default='Situação:\n\n\nSolução proposta:\n\n')
	anexo = JSONField(blank=True, default=list)
	status = models.ForeignKey(StatusDeHistoriaDeUsuario, on_delete=models.PROTECT, related_name='historias_de_usuario')
	participantes = models.ManyToManyField(Usuario, related_name='historias_de_usuario_participantes')
	peso = models.IntegerField(choices=[(i, str(i)) for i in range(5)], default=0)
	projeto = models.ForeignKey(Projeto, on_delete=models.PROTECT, related_name='historias_de_usuario')
	prioridade = models.IntegerField(choices=[(i, str(i)) for i in range(5)], default=0)
	data_prevista = models.DateField(null=True, blank=True)
	data_entrega = models.DateField(null=True, blank=True)
	data_cadastro = models.DateTimeField(default=timezone.now)

	def __str__(self):
		return self.titulo

	class Meta:
		verbose_name = 'historia de usuário'
		verbose_name_plural = 'historias de usuários'
		db_table = 'historia_de_usuario'
		constraints = [
			UniqueConstraint(fields=['titulo'], name='unique_titulo_historia_de_usuario'),
		]
		indexes = [
			Index(fields=['titulo'], name='idx_titulo_historia_de_usuario'),
		]

