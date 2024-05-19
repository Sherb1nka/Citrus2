import { Component, Input,} from '@angular/core';
import {NgFor} from "@angular/common";
import { PresentationModel, PresentationSheetModel } from '../../../services/ApiClient.nswag';
@Component({
	selector: 'ctrs-presentation-sheetlist',
	standalone: true,
	imports: [NgFor],
	templateUrl: './presentation-sheetlist.component.html',
	styleUrl: './presentation-sheetlist.component.scss'
})
export class PresentationSheetlistComponent {	

	private _presentationSheets: PresentationSheetModel[] = [];

	get presentationSheets(): PresentationSheetModel[] {
		return this._presentationSheets;
	}

	@Input()
	set presentationSheets(presentationSheets: PresentationSheetModel[]) {	
		this._presentationSheets = presentationSheets;
	}
}
