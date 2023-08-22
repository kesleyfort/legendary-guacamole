#language: pt-br
#http://tfs.ons.org.br:8080/tfs/ONS/Time_074/_sprints/taskboard/Time_074%20Team/Time_074/Sprint%202?workitem=119122
Funcionalidade: Validar campos informados para exportação do arquivo de Padrão Diário

    Cenário: Validar exibição dos campos da aba Padrão Diário
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Padrão Diário"
        Quando clico no aba "Padrão Diário"
        Então devo ver os campos da aba "Padrão Diário"

    Cenário: Validar regras do campo Nome da aba Padrão Diário
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Padrão Diário"
        Quando clico no aba "Padrão Diário"
        E preencho o campo "Nome" na aba "Padrão Diário" com o valor "asdasd"
        Então devo ver o valor "asdasd" no campo "Nome" na aba "Padrão Diário"
        Quando preencho o campo "Nome" na aba "Padrão Diário" com o valor "a!s!d!a!s!d"
        Então devo ver o valor "asdasd" no campo "Nome" na aba "Padrão Diário"
        Quando preencho o campo "Nome" na aba "Padrão Diário" com o valor " a s d a s d"
        Então devo ver o valor "asdasd" no campo "Nome" na aba "Padrão Diário"
        Quando preencho o campo "Nome" na aba "Padrão Diário" com o valor "kL6mWQAhHY1iOCy3aAE7hv3hS976uBKPorlVMxeTZ2Vya1q4XtOYELsOpE9EbodgignyhOzn5Zc7NHOQRWBFbN2tNmy30ywmAVXHasP4IFC0otNyOhWOPffmvu4oG7OwC0aumtQjjN04qf917"
        Então devo ver o valor "kL6mWQAhHY1iOCy3aAE7hv3hS976uBKPorlVMxeTZ2Vya1q4XtOYELsOpE9EbodgignyhOzn5Zc7NHOQRWBFbN2tNmy30ywmAVXHasP4IFC0otNyOhWOPffmvu4oG7OwC0aumtQjjN04" no campo "Nome" na aba "Padrão Diário"
        Quando preencho o campo "Nome" na aba "Padrão Diário" com o valor ""
        Então devo ver o valor "" no campo "Nome" na aba "Padrão Diário"
        
        
        Cenário: Validar regras do campo Data inicial da aba Padrão Diário
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Padrão Diário"
        Quando clico no aba "Padrão Diário"
        E preencho o campo "Data inicial" na aba "Padrão Diário" com o valor "01/09/2020"
        Então devo ver o valor "01/09/2020" no campo "Data inicial" na aba "Padrão Diário"
        Quando preencho o campo "Data inicial" na aba "Padrão Diário" com o valor "01/09/2040"
        Então devo ver a mensagem de erro "Erro! A data final é menor que a data inicial." 
        
               
        Cenário: Validar regras do campo Data final da aba Padrão Diário
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Padrão Diário"
        Quando clico no aba "Padrão Diário"
        Quando preencho o campo "Data final" na aba "Padrão Diário" com o valor "01/09/1870"
        Então devo ver a mensagem de erro "Erro! A data final é menor que a data inicial."
        Quando preencho o campo "Data final" na aba "Padrão Diário" com o valor "01/09/2023"
        Então devo ver o valor "01/09/2023" no campo "Data final" na aba "Padrão Diário"