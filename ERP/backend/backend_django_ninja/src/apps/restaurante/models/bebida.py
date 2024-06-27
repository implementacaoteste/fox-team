# ./src/apps/restaurante/models/bebida.py

from django.db import models
from django.db.models import UniqueConstraint, Index

class Bebida(models.Model):
    descricao = models.CharField(max_length=150)
    ativo = models.BooleanField(default=True)

    def __str__(self):
        return self.descricao

    class Meta:
        verbose_name = 'bebida'
        verbose_name_plural = 'bebidas'
        db_table = 'bebida'



