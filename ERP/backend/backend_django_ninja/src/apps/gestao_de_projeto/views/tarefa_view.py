# ./src/apps/gestao_de_projeto/views/tarefa_view.py

from ninja import Router
from ..schemas.tarefa_schema import TarefaSchema
from ..services.tarefa_service import TarefaService

tarefa_router = Router()

@tarefa_router.get("/tarefa/")
def buscar_todos(request):
	tarefa_lista = TarefaService.buscar_todos()
	return [TarefaSchema.from_orm(tarefa) for tarefa in tarefa_lista]

@tarefa_router.post("/tarefa/")
def inserir(request, tarefa: TarefaSchema):
	tarefa = TarefaService.inserir(tarefa.dict())
	return TarefaSchema.from_orm(tarefa)

@tarefa_router.get("/tarefa/{id}")
def buscar_por_id(request, id: int):
	tarefa = TarefaService.buscar_por_id(id)
	return TarefaSchema.from_orm(tarefa)

@tarefa_router.put("/tarefa/{id}")
def alterar(request, id: int, tarefa: TarefaSchema):
	tarefa = TarefaService.alterar(id, tarefa.dict())
	return TarefaSchema.from_orm(tarefa)

@tarefa_router.delete("/tarefa/{id}")
def excluir(request, id: int):
	TarefaService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



