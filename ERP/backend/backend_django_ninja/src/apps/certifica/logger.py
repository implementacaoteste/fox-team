import logging
import os
from datetime import datetime
import pytz

# Defina o fuso horário
tz = pytz.timezone('America/Sao_Paulo')

# Obtém a data atual e formata o nome do arquivo de log
current_date = datetime.now(tz).strftime('%Y%m%d')
log_file_name = f'log-certifica-{current_date}.log'

# Define o caminho do arquivo de log relativo ao diretório atual da execução da aplicação
current_dir = os.path.dirname(os.path.abspath(__file__))
log_file_path = os.path.join(current_dir, 'logs', log_file_name)

# Cria o diretório se não existir
os.makedirs(os.path.dirname(log_file_path), exist_ok=True)

# Configuração básica do logger
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Custom Formatter para incluir o fuso horário correto
class TzFormatter(logging.Formatter):
    def __init__(self, tz, fmt=None, datefmt=None):
        super().__init__(fmt, datefmt)
        self.tz = tz

    def formatTime(self, record, datefmt=None):
        dt = datetime.fromtimestamp(record.created, self.tz)
        if datefmt:
            s = dt.strftime(datefmt)
        else:
            s = dt.strftime("%Y-%m-%d %H:%M:%S")
        return s

# Configura o handler do arquivo de log
file_handler = logging.FileHandler(log_file_path)
file_handler.setLevel(logging.INFO)
file_handler.setFormatter(TzFormatter(tz, '%(asctime)s %(levelname)s: %(message)s', '%Y-%m-%d %H:%M:%S'))
logger.addHandler(file_handler)

def get_logger():
    return logger
