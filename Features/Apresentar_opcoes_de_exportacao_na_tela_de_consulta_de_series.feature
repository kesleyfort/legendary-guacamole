#language: pt-br
#http://tfs.ons.org.br:8080/tfs/ONS/Time_074/_sprints/taskboard/Time_074%20Team/Time_074/Sprint%202?workitem=120726

Funcionalidade: Apresentar opções de exportação na tela de consulta de séries

    Cenário: Validar exibição do modal de exportação
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E seleciono a base "Oficial"
        Quando clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        
    Cenário: Validar exibição da aba "Padrão Mensal"
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E seleciono a base "Oficial"
        Quando clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Padrão Mensal"
        
    Cenário: Validar exibição da aba "Padrão Diário"
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E seleciono a base "Oficial"
        Quando clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Padrão Diário"

        
    Cenário: Validar exibição da aba "Vazões mensais"
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E seleciono a base "Oficial"
        Quando clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Vazões Mensais"

        
    Cenário: Validar exibição da aba vazpast
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        E seleciono a base "Oficial"
        Quando clico no botão "Consultar"
        Então o sistema deve mostrar a lista de resultados
        Quando seleciono a série na posição "1"
        E clico no botão "Exportar"
        Então devo ver o modal de exportação
        E ver a aba "Vazpast"
