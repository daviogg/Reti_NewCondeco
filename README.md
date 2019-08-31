# Reti_NewCondeco
.Net web application for learning

Step di configurazione per la solution:
  
  - Clonare il repository
  - Installare i pacchetti npm
  - Restore dei Nuget packages
  - Verificare che come start-up project si abbiano "Reti.NewCondeco.Api" e "Reti.NewCondeco.PL"
  - Impostare il project URL del progetto WEB API sull'indirizzo "https://localhost:44394/" (Per evitare CORS)
  - Impostare il project URL del progetto "Reti.NewCondeco.PL"   "https://localhost:44374/"
  - Lanciare lo script del DB per crearlo sulla propria macchina, lo script si trova all'interno del progetto "Reti.NewCondeco.Database"
