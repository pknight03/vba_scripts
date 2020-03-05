def openProject():
    from PyQt4.QtCore import *
    import qgis
    from qgis.core import QgsMapLayerRegistry, QgsVectorJoinInfo

    for layer in QgsMapLayerRegistry.instance().mapLayers().values():
    # If a layer name = postcode, define it as a variable called 'shp'
        if layer.name() == "postcode":
            qgis.utils.iface.setActiveLayer(layer)
            shp = qgis.utils.iface.activeLayer()

    for layer in QgsMapLayerRegistry.instance().mapLayers().values():
    # If a layer name = CRVsignups, define it as a variable called 'csv'
        if layer.name() == "CRVsignups":
            qgis.utils.iface.setActiveLayer(layer)
            csv = qgis.utils.iface.activeLayer()

# Set up join parameters
    shpField='pcode'
    csvField='pcode'
    joinObject = QgsVectorJoinInfo()
    joinObject.joinLayerId = csv.id()
    joinObject.joinFieldName = csvField
    joinObject.targetFieldName = shpField
    shp.addJoin(joinObject)

# Define fields to update and joined fields to copy values from
    ip1 = shp.fieldNameIndex('Total') 
    ip1_join = shp.fieldNameIndex('CRVsignups_Total')
    
    shp.startEditing()
    for feat in shp.getFeatures():
        shp.changeAttributeValue(feat.id(), ip1, feat.attributes()[ip1_join])
    shp.commitChanges()

# Remove join 
#    shp.removeJoin(csv.id())

def saveProject():
    pass

def closeProject():
    pass
