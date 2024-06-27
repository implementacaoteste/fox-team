# ./src/apps/gestao_de_projeto/views/status_de_tarefa_view.py

from ninja import Router
from ..schemas.status_de_tarefa_schema import StatusDeTarefaSchema
from ..services.status_de_tarefa_service import StatusDeTarefaService

status_de_tarefa_router = Router()

@status_de_tarefa_router.get("/status_de_tarefa/")
def buscar_todos(request):
	status_de_tarefa_lista = StatusDeTarefaService.buscar_todos()
	return [StatusDeTarefaSchema.from_orm(status_de_tarefa) for status_de_tarefa in status_de_tarefa_lista]

@status_de_tarefa_router.post("/status_de_tarefa/")
def inserir(request, status_de_tarefa: StatusDeTarefaSchema):
	status_de_tarefa = StatusDeTarefaService.inserir(status_de_tarefa.dict())
	return StatusDeTarefaSchema.from_orm(status_de_tarefa)

@status_de_tarefa_router.get("/status_de_tarefa/{id}")
def buscar_por_id(request, id: int):
	status_de_tarefa = StatusDeTarefaService.buscar_por_id(id)
	return StatusDeTarefaSchema.from_orm(status_de_tarefa)

@status_de_tarefa_router.put("/status_de_tarefa/{id}")
def alterar(request, id: int, status_de_tarefa: StatusDeTarefaSchema):
	status_de_tarefa = StatusDeTarefaService.alterar(id, status_de_tarefa.dict())
	return StatusDeTarefaSchema.from_orm(status_de_tarefa)

@status_de_tarefa_router.delete("/status_de_tarefa/{id}")
def excluir(request, id: int):
	StatusDeTarefaService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



