# ./src/apps/gestao_de_projeto/views/status_de_historia_de_usuario_view.py

from ninja import Router
from ..schemas.status_de_historia_de_usuario_schema import StatusDeHistoriaDeUsuarioSchema
from ..services.status_de_historia_de_usuario_service import StatusDeHistoriaDeUsuarioService

status_de_historia_de_usuario_router = Router()

@status_de_historia_de_usuario_router.get("/status_de_historia_de_usuario/")
def buscar_todos(request):
	status_de_historia_de_usuario_lista = StatusDeHistoriaDeUsuarioService.buscar_todos()
	return [StatusDeHistoriaDeUsuarioSchema.from_orm(status_de_historia_de_usuario) for status_de_historia_de_usuario in status_de_historia_de_usuario_lista]

@status_de_historia_de_usuario_router.post("/status_de_historia_de_usuario/")
def inserir(request, status_de_historia_de_usuario: StatusDeHistoriaDeUsuarioSchema):
	status_de_historia_de_usuario = StatusDeHistoriaDeUsuarioService.inserir(status_de_historia_de_usuario.dict())
	return StatusDeHistoriaDeUsuarioSchema.from_orm(status_de_historia_de_usuario)

@status_de_historia_de_usuario_router.get("/status_de_historia_de_usuario/{id}")
def buscar_por_id(request, id: int):
	status_de_historia_de_usuario = StatusDeHistoriaDeUsuarioService.buscar_por_id(id)
	return StatusDeHistoriaDeUsuarioSchema.from_orm(status_de_historia_de_usuario)

@status_de_historia_de_usuario_router.put("/status_de_historia_de_usuario/{id}")
def alterar(request, id: int, status_de_historia_de_usuario: StatusDeHistoriaDeUsuarioSchema):
	status_de_historia_de_usuario = StatusDeHistoriaDeUsuarioService.alterar(id, status_de_historia_de_usuario.dict())
	return StatusDeHistoriaDeUsuarioSchema.from_orm(status_de_historia_de_usuario)

@status_de_historia_de_usuario_router.delete("/status_de_historia_de_usuario/{id}")
def excluir(request, id: int):
	StatusDeHistoriaDeUsuarioService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



