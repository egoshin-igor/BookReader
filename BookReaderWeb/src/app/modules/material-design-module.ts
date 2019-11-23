import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { 
    MatSnackBarModule,
    MatStepperModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    MatIconModule,
    MatTabsModule,
    MatCardModule,
    MatSelectModule,
    MatMenuModule,
    MatCheckboxModule 
} from '@angular/material';
import {MatToolbarModule} from '@angular/material/toolbar'; 


@NgModule({
    exports: [
        MatDialogModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatTooltipModule,
        MatIconModule,
        MatTabsModule,
        MatCardModule,
        MatButtonModule,
        MatSelectModule,
        MatMenuModule,
        MatCheckboxModule,
        MatFormFieldModule,
        MatAutocompleteModule,
        MatStepperModule,
        MatInputModule,
        MatSnackBarModule,
        MatToolbarModule,
        MatCardModule,
        MatTabsModule
    ]
})
export class MaterialDesignModule {}
