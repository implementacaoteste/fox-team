# ./src/apps/cadastro/models/produto.py

from django.db import models

class Produto(models.Model):
    nome = models.CharField(max_length=150)
    preco = models.DecimalField(max_digits=10, decimal_places=2)
    quantidade = models.IntegerField()
    ativo = models.BooleanField(default=True)

    def __str__(self):
        return self.nome
