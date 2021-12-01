package construction.site.logistics.foreman.data;

import android.content.Context;
import android.util.Xml;
import android.widget.Toast;

import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;
import org.xmlpull.v1.XmlPullParserFactory;
import org.xmlpull.v1.XmlSerializer;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Paths;

import construction.site.logistics.foreman.R;


public class LoadConfig {
    private XmlPullParserFactory xmlPullParserFactory;
    public String filename;

    public String GetConfigString(String key){

        try {
            xmlPullParserFactory = XmlPullParserFactory.newInstance();
            xmlPullParserFactory.setNamespaceAware(false);
            XmlPullParser parser = xmlPullParserFactory.newPullParser();
            // access the xml file and convert it to input stream
            InputStream is = new FileInputStream(filename);
            parser.setInput(is, null);

            int eventType = parser.getEventType();
            String name = null;
            while (eventType != XmlPullParser.END_DOCUMENT){
                if(eventType == XmlPullParser.START_TAG){
                    name = parser.getName();
                    if(name.equals(key)){
                        return parser.nextText();
                    }
                }
                eventType = parser.next();
            }
        } catch (XmlPullParserException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    return "";
    }

    public static void saveConfig(String lang, Context context){
        try {
            File file = new File(context.getFilesDir(), "config.xml");
            if (file.exists()){
                file.delete();
            }
            FileOutputStream fos = new FileOutputStream(file);
            XmlSerializer serializer = Xml.newSerializer();
            serializer.setOutput(fos, "UTF-8");
            serializer.startDocument(null, Boolean.valueOf(true));
            serializer.setFeature("http://xmlpull.org/v1/doc/features.html#indent-output", true);

            serializer.startTag(null, "config");

            serializer.startTag(null, "language");
            serializer.text(lang);
            serializer.endTag(null, "language");

            serializer.endTag(null, "config");

            serializer.endDocument();
            serializer.flush();
            fos.close();

        } catch (FileNotFoundException e) {
            Toast.makeText(context, context.getResources().getString(R.string.error_file_not_found), Toast.LENGTH_SHORT).show();
        } catch (IOException e) {
            Toast.makeText(context, context.getResources().getString(R.string.error_write_file), Toast.LENGTH_SHORT).show();
        }



    }
}
