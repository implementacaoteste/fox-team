# ./src/apps/configuracao/views/permissao_view.py

from ninja import Router
from ..schemas.permissao_schema import PermissaoSchema
from ..services.permissao_service import PermissaoService

permissao_router = Router()

@permissao_router.get("/permissao/")
def buscar_todos(request):
	permissao_lista = PermissaoService.buscar_todos()
	return [PermissaoSchema.from_orm(permissao) for permissao in permissao_lista]

@permissao_router.post("/permissao/")
def inserir(request, permissao: PermissaoSchema):
	permissao = PermissaoService.inserir(permissao.dict())
	return PermissaoSchema.from_orm(permissao)

@permissao_router.get("/permissao/{id}")
def buscar_por_id(request, id: int):
	permissao = PermissaoService.buscar_por_id(id)
	return PermissaoSchema.from_orm(permissao)

@permissao_router.put("/permissao/{id}")
def alterar(request, id: int, permissao: PermissaoSchema):
	permissao = PermissaoService.alterar(id, permissao.dict())
	return PermissaoSchema.from_orm(permissao)

@permissao_router.delete("/permissao/{id}")
def excluir(request, id: int):
	PermissaoService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}


