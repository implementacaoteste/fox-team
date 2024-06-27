# ./src/apps/gestao_de_projeto/views/comentario_view.py

from ninja import Router
from ..schemas.comentario_schema import ComentarioSchema
from ..services.comentario_service import ComentarioService

comentario_router = Router()

@comentario_router.get("/comentario/")
def buscar_todos(request):
	comentario_lista = ComentarioService.buscar_todos()
	return [ComentarioSchema.from_orm(comentario) for comentario in comentario_lista]

@comentario_router.post("/comentario/")
def inserir(request, comentario: ComentarioSchema):
	comentario = ComentarioService.inserir(comentario.dict())
	return ComentarioSchema.from_orm(comentario)

@comentario_router.get("/comentario/{id}")
def buscar_por_id(request, id: int):
	comentario = ComentarioService.buscar_por_id(id)
	return ComentarioSchema.from_orm(comentario)

@comentario_router.put("/comentario/{id}")
def alterar(request, id: int, comentario: ComentarioSchema):
	comentario = ComentarioService.alterar(id, comentario.dict())
	return ComentarioSchema.from_orm(comentario)

@comentario_router.delete("/comentario/{id}")
def excluir(request, id: int):
	ComentarioService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



