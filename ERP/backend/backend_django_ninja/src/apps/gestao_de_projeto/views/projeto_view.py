# ./src/apps/gestao_de_projeto/views/projeto_view.py

from ninja import Router
from ..schemas.projeto_schema import ProjetoSchema
from ..services.projeto_service import ProjetoService

projeto_router = Router()

@projeto_router.get("/projeto/")
def buscar_todos(request):
	projeto_lista = ProjetoService.buscar_todos()
	return [ProjetoSchema.from_orm(projeto) for projeto in projeto_lista]

@projeto_router.post("/projeto/")
def inserir(request, projeto: ProjetoSchema):
	projeto = ProjetoService.inserir(projeto.dict())
	return ProjetoSchema.from_orm(projeto)

@projeto_router.get("/projeto/{id}")
def buscar_por_id(request, id: int):
	projeto = ProjetoService.buscar_por_id(id)
	return ProjetoSchema.from_orm(projeto)

@projeto_router.put("/projeto/{id}")
def alterar(request, id: int, projeto: ProjetoSchema):
	projeto = ProjetoService.alterar(id, projeto.dict())
	return ProjetoSchema.from_orm(projeto)

@projeto_router.delete("/projeto/{id}")
def excluir(request, id: int):
	ProjetoService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}



