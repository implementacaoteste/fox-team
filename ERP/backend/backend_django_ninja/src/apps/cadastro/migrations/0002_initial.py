# Generated by Django 5.0.6 on 2024-06-27 14:22

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('cadastro', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Produto',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('nome', models.CharField(max_length=150)),
                ('preco', models.DecimalField(decimal_places=2, max_digits=10)),
                ('quantidade', models.IntegerField()),
                ('ativo', models.BooleanField(default=True)),
            ],
        ),
    ]
