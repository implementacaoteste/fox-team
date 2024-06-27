# ./src/apps/configuracao/views/grupo_de_usuario_view.py

from ninja import Router
from ..schemas.grupo_de_usuario_schema import GrupoDeUsuarioSchema
from ..services.grupo_de_usuario_service import GrupoDeUsuarioService

grupo_de_usuario_router = Router()

@grupo_de_usuario_router.get("/grupo_de_usuario/")
def buscar_todos(request):
	grupo_de_usuario_lista = GrupoDeUsuarioService.buscar_todos()
	return [GrupoDeUsuarioSchema.from_orm(grupo_de_usuario) for grupo_de_usuario in grupo_de_usuario_lista]

@grupo_de_usuario_router.post("/grupo_de_usuario/")
def inserir(request, grupo_de_usuario: GrupoDeUsuarioSchema):
	grupo_de_usuario = GrupoDeUsuarioService.inserir(grupo_de_usuario.dict())
	return GrupoDeUsuarioSchema.from_orm(grupo_de_usuario)

@grupo_de_usuario_router.get("/grupo_de_usuario/{id}")
def buscar_por_id(request, id: int):
	grupo_de_usuario = GrupoDeUsuarioService.buscar_por_id(id)
	return GrupoDeUsuarioSchema.from_orm(grupo_de_usuario)

@grupo_de_usuario_router.put("/grupo_de_usuario/{id}")
def alterar(request, id: int, grupo_de_usuario: GrupoDeUsuarioSchema):
	grupo_de_usuario = GrupoDeUsuarioService.alterar(id, grupo_de_usuario.dict())
	return GrupoDeUsuarioSchema.from_orm(grupo_de_usuario)

@grupo_de_usuario_router.delete("/grupo_de_usuario/{id}")
def excluir(request, id: int):
	GrupoDeUsuarioService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



