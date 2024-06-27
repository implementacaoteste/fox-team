# ./src/apps/configuracao/views/usuario_view.py

import csv
from ninja import Router, File
from ninja.errors import HttpError
from ninja.files import UploadedFile
from ..schemas.usuario_schema import UsuarioSchema
from ..services.usuario_service import UsuarioService

usuario_router = Router()

@usuario_router.get("/usuario/")
def buscar_todos(request):
	usuario_lista = UsuarioService.buscar_todos()
	return [UsuarioSchema.from_orm(usuario) for usuario in usuario_lista]

@usuario_router.post("/usuario/")
def inserir(request, usuario: UsuarioSchema):
	usuario = UsuarioService.inserir(usuario.dict())
	return UsuarioSchema.from_orm(usuario)

@usuario_router.get("/usuario/{id}")
def buscar_por_id(request, id: int):
	usuario = UsuarioService.buscar_por_id(id)
	return UsuarioSchema.from_orm(usuario)

@usuario_router.put("/usuario/{id}")
def alterar(request, id: int, usuario: UsuarioSchema):
	usuario = UsuarioService.alterar(id, usuario.dict())
	return UsuarioSchema.from_orm(usuario)

@usuario_router.delete("/usuario/{id}")
def excluir(request, id: int):
	UsuarioService.excluir(id)
	return {"mensagem": "Registro excluído com sucesso!"}

@usuario_router.post("/usuario/upload-csv/")
def upload_csv(request, file: UploadedFile = File(...)):
    try:
        decoded_file = file.read().decode('utf-8').splitlines()
        reader = csv.DictReader(decoded_file)
        
        usuarios = []
        for item in reader:
            usuario_data = {
                "nome": item.get("nome"),
                "nome_usuario": item.get("nome_usuario"),
                "email": item.get("email"),
                "grupos": item.get("grupos"),
                "url_foto": item.get("url_foto"),
                "ativo": item.get("ativo").lower() == 'true',  # Convertendo string para booleano
            }
            print(f"Dados recebidos para inserção: {usuario_data}")
            try:
                usuario = UsuarioService.inserir(usuario_data)
                usuarios.append(usuario)
            except Exception as e:
                print(f"Erro ao inserir o usuário: {e}")
                raise HttpError(400, f"Erro ao inserir o usuário: {e}")

        return {"mensagem": f"{len(usuarios)} usuários inseridos com sucesso!"}
    except Exception as e:
        print(f"Erro ao processar o arquivo CSV: {e}")
        raise HttpError(400, f"Erro ao processar o arquivo CSV: {e}")


