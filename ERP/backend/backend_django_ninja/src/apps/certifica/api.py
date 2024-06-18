# ./src/apps/certifica/api.py

from ninja import NinjaAPI
from .views.certificado_view import certificado_router

api = NinjaAPI(urls_namespace='certifica-api')
api.add_router('/certificado', certificado_router)