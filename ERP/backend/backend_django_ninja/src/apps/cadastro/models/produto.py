# ./src/apps/cadastro/models/produto.py

from django.db import models
from django.db.models import UniqueConstraint, Index

class Produto(models.Model):
    nome = models.CharField(max_length=150)
    preco = models.DecimalField(max_digits=10, decimal_places=2)
    quantidade = models.IntegerField()
    ativo = models.BooleanField(default=True)

    def __str__(self):
        return self.nome
    
    class Meta:
        verbose_name = 'produto'
        verbose_name_plural = 'produtos'
        db_table = 'produto'
        constraints = [
            UniqueConstraint(fields=['nome'], name='unique_nome'),
        ]
        indexes = [
            Index(fields=['nome'], name='idx_nome'),
        ]
