# ./src/apps/restaurante/models/atendente.py

from django.db import models
from django.db.models import UniqueConstraint, Index

class Atendente(models.Model):
    nome = models.CharField(max_length=150)
    cpf = models.CharField(max_length=11, null=True, blank=True)
    fone = models.CharField(max_length=15)
    ativo = models.BooleanField(default=True)

    def __str__(self):
        return self.nome  # Corrigido para retornar 'nome'

    class Meta:
        verbose_name = 'atendente'
        verbose_name_plural = 'atendentes'
        db_table = 'atendente'
        constraints = [
            UniqueConstraint(fields=['cpf'], name='unique_cpf')
        ]

