select IdProyecto, FolioProyecto, NombreProyecto, 
(select isnull(sum(Total),0.00) from tblOrdenCompra where convert(varchar(150),IdProyecto) = p.IdProyecto) as oc
,(select isnull(sum(Abono),0.00) from tblCajaChica where convert(varchar(150),IdProyecto) = convert(varchar(150),p.IdProyecto)) as cc
,(select isnull(sum(Total),0.00) from tblControlFacturas where convert(varchar(150),IdProyecto) = convert(varchar(150),p.IdProyecto)) as cf
,(select isnull(sum(CantEntregada),0.00) from tblViaticos where convert(varchar(150),IdProyecto) = convert(varchar(150),p.IdProyecto)) as v
from tblProyectos p
where IdProyecto = '4E327B4E-931D-4E04-A185-A72AE297D4D1'

