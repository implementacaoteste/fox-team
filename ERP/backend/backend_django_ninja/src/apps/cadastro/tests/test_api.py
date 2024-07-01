# apps/cadastro/tests/test_api.py

import pytest
from django.test import Client

@pytest.fixture
def api_client():
    return Client()

@pytest.mark.django_db
def test_get_produto(api_client):
    response = api_client.get('/api/cadastro-produto/produto/')
    assert response.status_code == 200
    assert response.json() == []  # Ajuste conforme a resposta esperada

@pytest.mark.django_db
def test_create_produto(api_client):
    data = {
        "nome": "Fumo Maratá",
        "preco": 8.8,
        "quantidade": 15,
        "ativo": True
    }
    response = api_client.post('/api/cadastro-produto/produto/', data, content_type='application/json')
    assert response.status_code == 200
    assert response.json()['nome'] == "Fumo Maratá"
