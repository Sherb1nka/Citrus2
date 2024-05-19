import { Component, Input,} from '@angular/core';
import {NgFor} from "@angular/common";
import { PresentationDTO, PresentationSheetDTO } from '../../../services/ApiClient.nswag';
@Component({
	selector: 'ctrs-presentation-sheetlist',
	standalone: true,
	imports: [NgFor],
	templateUrl: './presentation-sheetlist.component.html',
	styleUrl: './presentation-sheetlist.component.scss'
})
export class PresentationSheetlistComponent {	

	private _presentationSheets: PresentationSheetDTO[] = [];

	get presentationSheets(): PresentationSheetDTO[] {
		return this._presentationSheets;
	}

	@Input()
	set presentationSheets(presentationSheets: PresentationSheetDTO[]) {	
		this._presentationSheets = presentationSheets;
	}
}
