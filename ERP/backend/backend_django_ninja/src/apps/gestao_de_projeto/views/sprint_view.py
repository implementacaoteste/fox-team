# ./src/apps/gestao_de_projeto/views/sprint_view.py

from ninja import Router
from ..schemas.sprint_schema import SprintSchema
from ..services.sprint_service import SprintService

sprint_router = Router()

@sprint_router.get("/sprint/")
def buscar_todos(request):
	sprint_lista = SprintService.buscar_todos()
	return [SprintSchema.from_orm(sprint) for sprint in sprint_lista]

@sprint_router.post("/sprint/")
def inserir(request, sprint: SprintSchema):
	sprint = SprintService.inserir(sprint.dict())
	return SprintSchema.from_orm(sprint)

@sprint_router.get("/sprint/{id}")
def buscar_por_id(request, id: int):
	sprint = SprintService.buscar_por_id(id)
	return SprintSchema.from_orm(sprint)

@sprint_router.put("/sprint/{id}")
def alterar(request, id: int, sprint: SprintSchema):
	sprint = SprintService.alterar(id, sprint.dict())
	return SprintSchema.from_orm(sprint)

@sprint_router.delete("/sprint/{id}")
def excluir(request, id: int):
	SprintService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



