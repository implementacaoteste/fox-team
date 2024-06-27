# ./src/apps/gestao_de_projeto/views/historia_de_usuario_view.py

from ninja import Router
from ..schemas.historia_de_usuario_schema import HistoriaDeUsuarioSchema
from ..services.historia_de_usuario_service import HistoriaDeUsuarioService

historia_de_usuario_router = Router()

@historia_de_usuario_router.get("/historia_de_usuario/")
def buscar_todos(request):
	historia_de_usuario_lista = HistoriaDeUsuarioService.buscar_todos()
	return [HistoriaDeUsuarioSchema.from_orm(historia_de_usuario) for historia_de_usuario in historia_de_usuario_lista]

@historia_de_usuario_router.post("/historia_de_usuario/")
def inserir(request, historia_de_usuario: HistoriaDeUsuarioSchema):
	historia_de_usuario = HistoriaDeUsuarioService.inserir(historia_de_usuario.dict())
	return HistoriaDeUsuarioSchema.from_orm(historia_de_usuario)

@historia_de_usuario_router.get("/historia_de_usuario/{id}")
def buscar_por_id(request, id: int):
	historia_de_usuario = HistoriaDeUsuarioService.buscar_por_id(id)
	return HistoriaDeUsuarioSchema.from_orm(historia_de_usuario)

@historia_de_usuario_router.put("/historia_de_usuario/{id}")
def alterar(request, id: int, historia_de_usuario: HistoriaDeUsuarioSchema):
	historia_de_usuario = HistoriaDeUsuarioService.alterar(id, historia_de_usuario.dict())
	return HistoriaDeUsuarioSchema.from_orm(historia_de_usuario)

@historia_de_usuario_router.delete("/historia_de_usuario/{id}")
def excluir(request, id: int):
	HistoriaDeUsuarioService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



