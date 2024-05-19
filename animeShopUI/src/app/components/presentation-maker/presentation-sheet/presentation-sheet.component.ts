import { Component, Output, EventEmitter, OnInit} from '@angular/core';

// Import all Froala Editor plugins.
import 'froala-editor/js/plugins.pkgd.min.js';

// Import a single Froala Editor plugin.
import 'froala-editor/js/plugins/align.min.js';

// Import a Froala Editor language file.
import 'froala-editor/js/languages/de.js';

// Import a third-party plugin.
import 'froala-editor/js/third_party/font_awesome.min';
import 'froala-editor/js/third_party/image_tui.min';
import 'froala-editor/js/third_party/spell_checker.min';
import 'froala-editor/js/third_party/embedly.min';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { EDIT_SLIDE } from '../constants';
import html2canvas from 'html2canvas';
import { PresentationSheetModel } from '../../../services/ApiClient.nswag';

@Component({
	selector: 'ctrs-presentation-sheet',
	standalone: true,
	imports: [
		FroalaEditorModule,
		FroalaViewModule
	],
	templateUrl: './presentation-sheet.component.html',
	styleUrl: './presentation-sheet.component.scss'
})
export class PresentationSheetComponent {	
	
	editorContent: string = EDIT_SLIDE;
	
	private _presentationSheet: PresentationSheetModel = new PresentationSheetModel;

	get presentationSheet(): PresentationSheetModel {
		return this._presentationSheet;
	}

	set presentationSheet(presentationSheet: PresentationSheetModel) {
		this._presentationSheet = presentationSheet;
	}
	

	@Output()
	onSlideSave = new EventEmitter<PresentationSheetModel>();

	makeSnapshot() {
		html2canvas(document.querySelector("#capture") as HTMLElement).then((canvas) => {
			let imageUrl = canvas.toDataURL("image/png");
			this._presentationSheet.imgUrl = canvas.toDataURL("image.png");
			this._presentationSheet.htmlText = this.editorContent;
			this.saveSlide();
		});
	}

	saveSlide() {
		this.onSlideSave.emit(this.presentationSheet)
	}

}
