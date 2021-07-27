import bpy

#################################### BLENRIG UPDATE OPERATOR ####################################################

# Biped

class Operator_Biped_Updater(bpy.types.Operator):     
    bl_idname = "blenrig5.biped_updater"  
    bl_label = "BlenRig 5 Biped Rig Updater"     
    bl_description = "Update BlenRig 5 biped rig to the latest version"    
    bl_options = {'REGISTER', 'UNDO'}

    @classmethod
    def poll(cls, context):
        if not bpy.context.object:
            return False
        if (bpy.context.active_object.type in ["ARMATURE"]):
            for prop in bpy.context.active_object.data.items():
                if prop[0] == 'rig_name' and prop[1] == 'BlenRig_5':
                    for propb in bpy.context.active_object.data.items():
                        if propb[0] == 'rig_type' and propb[1] == 'Biped':
                            return True      

    def execute(self, context):
        arm = bpy.context.active_object
        #### Update 0.001 ####
        if arm.data['rig_version'] == 1.0:
            # Load Update Functions
            from .blenrig_biped.updates.update_1001 import (biped_update_1001)
            # Apply
            biped_update_1001(self, context)
            
        #### Update 0.005 ####
        if arm.data['rig_version'] < 1.005:
            # Load Update Functions
            from .blenrig_biped.updates.update_1005 import (
            biped_update_1005_drivers,
            biped_update_1005_locks,
            biped_update_1005_bone_layers,
            biped_update_1005_bone_groups,
            biped_update_1005_bone_shapes,
            biped_update_1005_new_bones,
            biped_update_1005_lattices,
            biped_update_1005_protected_layers,
            biped_update_1005_functions_script,
            biped_update_1005_layer_scheme,
            biped_update_1005_update_version
            )            
            # Apply
            biped_update_1005_drivers(self, context)
            biped_update_1005_locks(self, context)
            biped_update_1005_bone_layers(self, context)
            biped_update_1005_bone_groups(self, context)
            biped_update_1005_bone_shapes(self, context)
            biped_update_1005_new_bones(self, context)
            biped_update_1005_lattices(self, context)
            biped_update_1005_protected_layers(self, context)
            biped_update_1005_functions_script(self, context)
            biped_update_1005_layer_scheme(self, context)
            biped_update_1005_update_version(self, context)
          
        else:
            self.report({'INFO'}, 'Armature already up to date')                            
        return {"FINISHED"}    